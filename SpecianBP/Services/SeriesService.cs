using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpecianBP.Api;
using SpecianBP.Api.Dto;
using SpecianBP.Db;
using SpecianBP.Entities;

namespace SpecianBP.Services
{
    public class SeriesService
    {
        protected readonly DbService _dbService;

        public SeriesService(DbService context)
        {
            _dbService = context;
        }

        public string GetSeriesUnit(string SeriesName)
        {
            var u = _dbService.SeriesUnit.Where(i => i.SeriesName == SeriesName).FirstOrDefault();

            if (u != null)
            {
                return u.UnitName;
            }
            else return "";
        }

        /// <summary>
        /// Averaging filter on selected data
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <param name="Step"></param>
        /// <param name="SeriesName"></param>
        /// <returns></returns>
        public IList GetAveraged(DateTime From, DateTime To, TimeSpan Step, string SeriesName, int MeasurementPlaceNumberId = 1)
        {
            string seriesUnit = GetSeriesUnit(SeriesName);
            // divide
            var data = resolveType(From, To, SeriesName, MeasurementPlaceNumberId);

            if (isStatusType(SeriesName))  //shlould not be averaged boolean parametres
            {
                var resultStatuses = new List<SeriesAveragedDto>();
                foreach (var d in data)
                {
                    if (d.StatusValue)
                    {
                        d.Value = 1F;
                    }
                    else
                    {
                        d.Value = 0F;
                    }
                    resultStatuses.Add(new SeriesAveragedDto() { AverageValue = d.Value, FromTime = d.Time, ToTime = d.Time, SeriesName = SeriesName, Unit = "boolean" });
                }
                return resultStatuses;
            }

            if (Step == TimeSpan.Zero)
            {
                return data.Select(i => new SeriesAveragedDto() { AverageValue = i.Value, FromTime = i.Time, ToTime = i.Time, SeriesName = SeriesName, Unit = seriesUnit }).ToList();
            }

            DateTime intervalSart = From;
            DateTime intervalEnd = From + Step;

            List<List<TimeValuePairDto>> grouped = new List<List<TimeValuePairDto>>();
            var result = new List<SeriesAveragedDto>();
            bool lastPart = false;
            do
            {
                var group = data.Where(i => i.Time >= intervalSart && i.Time <= intervalEnd).ToList();
                if (group.Count() > 0)
                {
                    grouped.Add(group);
                    SeriesAveragedDto averaged = new SeriesAveragedDto();
                    averaged.FromTime = intervalSart;
                    averaged.ToTime = intervalEnd;
                    averaged.AverageValue = group.Select(i => i.Value).Average();
                    averaged.SeriesName = SeriesName;
                    averaged.MinValue = group.Select(i => i.Value).Min();
                    averaged.MaxValue = group.Select(i => i.Value).Max();
                    averaged.Unit = seriesUnit;
                    result.Add(averaged);
                    intervalSart = intervalEnd;
                }
                if (intervalEnd + Step > To && !lastPart)
                {
                    intervalEnd = To;
                    lastPart = true;
                }
                else
                {
                    intervalEnd = intervalEnd + Step;
                }
            } while (intervalEnd < (To + Step) || !lastPart);
            return result;
        }

        private bool isStatusType(string SeriesName)
        {
            var names =
            typeof(Status).GetProperties()
                .Select(property => property.Name)
                .ToList();
            if (names.Contains(SeriesName))
            {
                return true;
            }
            else return false;
        }

        private List<TimeValuePairDto> resolveType(DateTime From, DateTime To, string SeriesName, int MeasurementPlaceNumberId)
        {

            var names = typeof(Power).GetProperties()
                        .Select(property => property.Name)
                        .ToList();
            if (names.Contains(SeriesName))
            {
                return _dbService.Power
                    .Where(i => i.MeasurementPlaceNumberId == MeasurementPlaceNumberId)
                    .Where(i => i.TimeLocal >= From && i.TimeLocal <= To)
               .OrderBy(i => i.TimeLocal)
               .Select(i => new TimeValuePairDto() { Time = i.TimeLocal, Value = (float)i.GetType().GetProperty(SeriesName).GetValue(i, null), SeriesName = SeriesName })
               .ToList();
            }

            names = typeof(Voltage).GetProperties()
                    .Select(property => property.Name)
                    .ToList();
            if (names.Contains(SeriesName))
            {
                return _dbService.Voltages
                    .Where(i => i.MeasurementPlaceNumberId == MeasurementPlaceNumberId)
                    .Where(i => i.TimeLocal >= From && i.TimeLocal <= To)
                .OrderBy(i => i.TimeLocal)
                .Select(i => new TimeValuePairDto() { Time = i.TimeLocal, Value = (float)i.GetType().GetProperty(SeriesName).GetValue(i, null), SeriesName = SeriesName })
                .ToList();
            }
            names =
            typeof(Current).GetProperties()
                .Select(property => property.Name)
                .ToList();
            if (names.Contains(SeriesName))
            {
                return _dbService.Current
                    .Where(i => i.MeasurementPlaceNumberId == MeasurementPlaceNumberId)
                    .Where(i => i.TimeLocal >= From && i.TimeLocal <= To)
                .OrderBy(i => i.TimeLocal)
                .Select(i => new TimeValuePairDto() { Time = i.TimeLocal, Value = (float)i.GetType().GetProperty(SeriesName).GetValue(i, null), SeriesName = SeriesName })
                .ToList();
            }
            names =
            typeof(Frequency).GetProperties()
                .Select(property => property.Name)
                .ToList();
            if (names.Contains(SeriesName))
            {
                return _dbService.Frequency
                    .Where(i => i.MeasurementPlaceNumberId == MeasurementPlaceNumberId)
                    .Where(i => i.TimeLocal >= From && i.TimeLocal <= To)
               .OrderBy(i => i.TimeLocal)
               .Select(i => new TimeValuePairDto() { Time = i.TimeLocal, Value = (float)i.GetType().GetProperty(SeriesName).GetValue(i, null), SeriesName = SeriesName })
               .ToList();
            }
            names =
            typeof(Status).GetProperties()
                .Select(property => property.Name)
                .ToList();
            if (names.Contains(SeriesName))
            {
                return _dbService.Status
                    .Where(i => i.MeasurementPlaceNumberId == MeasurementPlaceNumberId)
                    .Where(i => i.TimeLocal >= From && i.TimeLocal <= To)
               .OrderBy(i => i.TimeLocal)
               .Select(i => new TimeValuePairDto() { Time = i.TimeLocal, StatusValue = (bool)i.GetType().GetProperty(SeriesName).GetValue(i, null), SeriesName = SeriesName })
               .ToList();
            }
            names =
            typeof(Temperature).GetProperties()
                .Select(property => property.Name)
                .ToList();
            if (names.Contains(SeriesName))
            {
                return _dbService.Temperature
                    .Where(i => i.MeasurementPlaceNumberId == MeasurementPlaceNumberId)
                    .Where(i => i.TimeLocal >= From && i.TimeLocal <= To)
               .OrderBy(i => i.TimeLocal)
               .Select(i => new TimeValuePairDto() { Time = i.TimeLocal, Value = (float)i.GetType().GetProperty(SeriesName).GetValue(i, null), SeriesName = SeriesName })
               .ToList();
            }
            return null;
        }

    }
}
