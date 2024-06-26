using System;
using System.Collections.Generic;
using GeolettApi.Domain.Models;

namespace GeolettApi.Domain.Models
{
    public class RegisterItem : EntityBase
    {
        public string ContextType { get; set; }
        public Guid Uuid { get; set; }
        public int OwnerId { get; set; }
        public Organization Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status? Status { get; set; } = GeolettApi.Domain.Models.Status.Submitted;
        public List<RegisterItemLink> Links { get; set; }
        public string DialogText { get; set; }
        public string PossibleMeasures { get; set; }
        public string Guidance { get; set; }
        public int? DataSetId { get; set; }
        public DataSet DataSet { get; set; }
        public int? ReferenceId { get; set; }
        public Reference Reference { get; set; }
        public string TechnicalComment { get; set; }
        public string OtherComment { get; set; }
        public string Sign1 { get; set; }
        public string Sign2 { get; set; }
        public string Sign3 { get; set; }
        public string Sign4 { get; set; }
        public string Sign5 { get; set; }
        public string Sign6 { get; set; }
        public DateTime? LastUpdated { get; set; }

        public override void Update(EntityBase updatedEntity)
        {
            var updated = (RegisterItem) updatedEntity;

            if (ContextType != updated.ContextType)
                ContextType = updated.ContextType;

            if (Title != updated.Title)
                Title = updated.Title;

            if (Description != updated.Description)
                Description = updated.Description;

            if (Status != updated.Status)
                Status = updated.Status;

            UpdateList(Links, updated.Links);

            if (DialogText != updated.DialogText)
                DialogText = updated.DialogText;

            if (PossibleMeasures != updated.PossibleMeasures)
                PossibleMeasures = updated.PossibleMeasures;

            if (Guidance != updated.Guidance)
                Guidance = updated.Guidance;
            if(updated.DataSet != null) { 
                if(DataSet == null) {
                    DataSet = new DataSet();
                }
                DataSet.Update(updated.DataSet);
            }

            if (updated.Reference != null) {
                if (Reference == null)
                    Reference = new Reference();
            Reference.Update(updated.Reference);
            }

            //set reference to null since added to links
            updated.Reference = null;

            if (TechnicalComment != updated.TechnicalComment)
                TechnicalComment = updated.TechnicalComment;

            if (OtherComment != updated.OtherComment)
                OtherComment = updated.OtherComment;

            if (Sign1 != updated.Sign1)
                Sign1 = updated.Sign1;

            if (Sign2 != updated.Sign2)
                Sign2 = updated.Sign2;

            if (Sign3 != updated.Sign3)
                Sign3 = updated.Sign3;

            if (Sign4 != updated.Sign4)
                Sign4 = updated.Sign4;

            if (Sign5 != updated.Sign5)
                Sign5 = updated.Sign5;

            if (Sign6 != updated.Sign6)
                Sign6 = updated.Sign6;

            if (OwnerId != updated.OwnerId)
                OwnerId = updated.OwnerId;
        }
    }
}
