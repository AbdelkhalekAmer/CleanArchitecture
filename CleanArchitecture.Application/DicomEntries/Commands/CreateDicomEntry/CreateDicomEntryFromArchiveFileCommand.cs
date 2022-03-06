using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;

using MediatR;

namespace CleanArchitecture.Application.DicomEntries.Commands.CreateDicomEntry;

public class CreateDicomEntryFromArchiveFileCommand : IRequest
{
    public CreateDicomEntryFromArchiveFileCommand(string archiveFileFullName, string archiveFileExtractionDestination)
    {
        ArchiveFileFullName = archiveFileFullName;
        ArchiveFileExtractionDestination = archiveFileExtractionDestination;
    }

    public string ArchiveFileFullName { get; set; }
    public string ArchiveFileExtractionDestination { get; set; }

    public class CreateDicomEntryFromArchiveFileHandler : IRequestHandler<CreateDicomEntryFromArchiveFileCommand>
    {
        private readonly IDicomDbContext _dicomDbContext;
        private readonly IDicomReader<DicomEntry> _dicomReader;
        private readonly IArchiveFileExtractor _archiveFileExtractor;
        public CreateDicomEntryFromArchiveFileHandler(IDicomDbContext dicomDbContext,
            IDicomReader<DicomEntry> dicomReader,
            IArchiveFileExtractor archiveFileExtractor)
        {
            _dicomReader = dicomReader;
            _dicomDbContext = dicomDbContext;
            _archiveFileExtractor = archiveFileExtractor;
        }

        public async Task<Unit> Handle(CreateDicomEntryFromArchiveFileCommand request, CancellationToken cancellationToken)
        {
            await _archiveFileExtractor.ExtractAsync(request.ArchiveFileFullName, request.ArchiveFileExtractionDestination);

            var dicomEntry = await _dicomReader.ReadDirectoryAsync(request.ArchiveFileExtractionDestination, cancellationToken);

            await _dicomDbContext.DicomEntries.AddAsync(dicomEntry, cancellationToken);

            await _dicomDbContext.SaveChangesAsync(cancellationToken);

            // complete message

            return Unit.Value;
        }
    }
}
