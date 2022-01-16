﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SoftJail.Data.Models;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerImportDto
    {
        public PrisonerImportDto()
        {
            Mails = new List<MailImportDto>();
        }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression("[The]+ [A-Z][a-z]+")]
        public string Nickname { get; set; }

        [Required]
        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public ICollection<MailImportDto> Mails { get; set; }
    }
}
