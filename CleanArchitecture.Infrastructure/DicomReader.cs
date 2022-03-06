

using FellowOakDicom;
using FellowOakDicom.Media;

using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enumerations;

using Entities = CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure;

public class DicomReader : IDicomReader<Entities.DicomEntry>
{
    public async Task<Entities.DicomEntry> ReadDirectoryAsync(string path, CancellationToken cancellationToken)
    {
        var dicomdirFilePath = Path.Combine(path, "DICOMDIR");

        using var dicomdirFileStream = File.OpenRead(dicomdirFilePath);

        var dicomDirectory = await DicomDirectory.OpenAsync(dicomdirFileStream);

        var patientRecord = dicomDirectory.RootDirectoryRecord;

        patientRecord.TryGetString(DicomTag.PatientAge, out var age);

        var patient = new Entities.Patient()
        {
            SourceName = "",
            SourceUid = patientRecord.GetString(DicomTag.PatientID),
            FirstName = patientRecord.GetString(DicomTag.PatientName),
            //Age = Convert.ToInt32(age),
            //Gender = patientRecord.GetString(DicomTag.PatientSex) == "M" ? Gender.Male : Gender.Female
        };

        patientRecord.LowerLevelDirectoryRecordCollection
            .Each(studyRecord =>
            {
                var dateTime = studyRecord.GetDateTime(DicomTag.StudyDate, DicomTag.StudyTime);
                var study = new Entities.Study()
                {
                    SourceName = studyRecord.GetString(DicomTag.StudyID),
                    SourceUid = studyRecord.GetString(DicomTag.StudyInstanceUID),
                    Description = studyRecord.GetString(DicomTag.StudyDescription),
                    Date = dateTime.Date,
                    Time = dateTime.TimeOfDay
                };
                studyRecord.LowerLevelDirectoryRecordCollection.Each(seriesRecord =>
                {
                    try
                    {
                        var dateTime = seriesRecord.GetDateTime(DicomTag.SeriesDate, DicomTag.SeriesTime);
                        var series = new Entities.Series()
                        {
                            SourceName = "",
                            SourceUid = seriesRecord.GetString(DicomTag.SeriesInstanceUID),
                            //Description = seriesRecord.GetString(DicomTag.SeriesDescription),
                            Number = Convert.ToInt32(seriesRecord.GetString(DicomTag.SeriesNumber)),
                            Date = dateTime.Date,
                            Time = dateTime.TimeOfDay
                        };
                        seriesRecord.LowerLevelDirectoryRecordCollection.Each(instanceRecord =>
                        {
                            series.Instances.Add(new Entities.Instance()
                            {
                                SourceName = "",
                                SourceUid = "",
                                //SOPClassUID = instanceRecord.GetString(DicomTag.SOPClassUID),
                                //SOPInstanceUid = instanceRecord.GetString(DicomTag.SOPInstanceUID),
                                File = new Entities.File()
                                {
                                    Name = "",
                                    FullName = "",
                                    Extension = ""
                                }
                            });
                        });
                        study.Series.Add(series);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                });
                patient.Studies.Add(study);
            });

        return new Entities.DicomEntry() { Patient = patient };
    }

    public Task<Entities.DicomEntry> ReadFileAsync(string path, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
