using System.Collections.Generic;

namespace DAL
{
    public interface Obrigatorio<QualquerClasse>
    {
        void create(QualquerClasse obj);
        void delete(QualquerClasse obj);
        void update(QualquerClasse obj);
        bool find(QualquerClasse obj);
        List<QualquerClasse> findAll();
    }
}
