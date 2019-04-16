using System;
using System.Collections.Generic;

namespace ExposureEvents.API.Models
{
    public class ExposureEvent
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public ExposureOrganization Organization { get; set; }
        public bool Archive { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }
        public string TimeZone { get; set; }
        public DateTime EndDate { get; set; }
        public ExposureAddress Address { get; set; }
        public IEnumerable<ExposureDivision> Divisions { get; set; } = new List<ExposureDivision>();
        public IEnumerable<ExposureAssets> Assets { get; set; } = new List<ExposureAssets>();
        public IEnumerable<ExposureVenue> Venues { get; set; } = new List<ExposureVenue>();
        public IEnumerable<ExposurePrice> Prices { get; set; } = new List<ExposurePrice>();
        public ExposureSettings Settings { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public IEnumerable<ExposureCertification> Certifications { get; set; } = new List<ExposureCertification>();
        public ExposureSeason Season { get; set; }
        public string InstagramHandle { get; set; }
        public string TwitterHandle { get; set; }
        public string Website { get; set; }
        public string FacebookPage { get; set; }
    }
}