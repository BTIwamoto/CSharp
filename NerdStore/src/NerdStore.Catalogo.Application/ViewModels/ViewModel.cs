using System;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalogo.Application.ViewModels
{
    public class ViewModel
    {
        [Key]
        public Guid Id { get; }

        protected ViewModel()
        {
            Id = new Guid();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as ViewModel;

            if (ReferenceEquals(this, compareTo))
                return true;

            return !ReferenceEquals(null, compareTo) && Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 913) + Id.GetHashCode();
        }
    }
}