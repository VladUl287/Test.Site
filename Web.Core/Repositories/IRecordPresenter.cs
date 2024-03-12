using Web.Core.Dtos;

namespace Web.Core;

public interface IRecordPresenter
{
    Task<RecordResult> GetAll(PageFilter? pageFilter);
}
