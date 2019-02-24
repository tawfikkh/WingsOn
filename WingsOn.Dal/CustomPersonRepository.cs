using System.Linq;
using WingsOn.Domain;

namespace WingsOn.Dal
{
    public class CustomPersonRepository : PersonRepository
    {
        public override void Save(Person person)
        {
            // assign id before save
            if (person.Id == 0) person.Id = Repository.Max(p => p.Id) + 1;
            base.Save(person);
        }
    }
}
