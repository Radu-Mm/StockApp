using System;
using System.Collections.Generic;

namespace StockApp.Models.DBObjects
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Documents = new HashSet<Document>();
        }

        public Guid DocTypeId { get; set; }
        public string? DocType { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
