namespace MarGate.Catalog.Application.Handlers.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryResponse
{
    public long Id { get; set; }
    public string Name { get; set; }

    // decriptionda eklemek gerekmez mi create ederken requestten descriptionda alıyoruz, bunu kullanıcı görmek isteği
    // zaman id ye veya get all categories dediğinde dönmek gerekmez mi
}
