using System;
using System.Collections.Generic;
using System.Text;
namespace CDAA_ProjectForms
{
    public interface LesComparaisons<T>
    {
        int CompareNom(T obj);
        int ComparePrix(T obj);

    }
}
