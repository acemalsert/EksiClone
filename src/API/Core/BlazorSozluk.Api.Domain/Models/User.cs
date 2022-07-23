namespace BlazorSozluk.Api.Domain.Models
{
    public class User:BaseEntity
    {
        public string FirstName;
        public string LastName;
        public string EmailAddress;
        public string UserName;
        public string Password;
        public bool EmailConfirmed;
        public virtual ICollection<Entry> Entries;
        public virtual ICollection<EntryComment> EntryComments;
        public virtual ICollection<EntryFavorite> EntryFavorites;
        public virtual ICollection<EntryCommentFavorite> EntryCommentFavorites;

    }
}
