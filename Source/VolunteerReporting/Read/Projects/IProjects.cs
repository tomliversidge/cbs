using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.Projects
{
    public interface IProjects : IGenericReadModelRepositoryFor<Project, Guid>
    {
        IEnumerable<Project> GetAll();
        Task<IEnumerable<Project>> GetAllAsync();
        Project GetById(Guid project);

        void SaveProject(Guid id, string name);
        Task SaveProjectAsync(Guid id, string name);

        UpdateResult UpdateProject(Guid id, string name);
        Task<UpdateResult> UpdateProjectAsync(Guid id, string name);
    }
}
