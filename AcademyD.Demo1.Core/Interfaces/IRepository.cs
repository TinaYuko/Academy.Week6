using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyD.Demo1.Core.Interfaces
{
    public interface IRepository<T>
    {
        // In questo punto scelgo di utilizzare IEnumerable al posto di IList, perche' IEnumerable e' il meno "specifico" (IList implementa IEnumerable)
        // e perche', trattandosi di una operazione di fetch, IEnumerable e' ottimizzato per operazioni di loop, mentre IList e' piu' indicato per
        // operazioni sulla lista come Count, l'aggiunta o la cancellazione di elementi
        IEnumerable<T> Fetch(Func<T, bool> filter = null);
        T GetById(string id);
        bool Add(T newItem);
        bool Update(T updatedItem);
        bool DeleteById(string id);
    }
}
