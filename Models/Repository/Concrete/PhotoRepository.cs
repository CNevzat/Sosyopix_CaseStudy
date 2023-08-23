using Sosyopix_CaseStudy.Models.Entity;
using Sosyopix_CaseStudy.Models.Repository.Abstract;
using Sosyopix_CaseStudy.Models.Utility;
using System.Linq.Expressions;

namespace Sosyopix_CaseStudy.Models.Repository.Concrete
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        private ApplicationDbContext _dbContext;
        public PhotoRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

    }
}
