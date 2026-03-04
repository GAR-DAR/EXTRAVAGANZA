using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class PostSpecification : BaseSpecification<Post>
{
    public PostSpecification(PostSpecParams specParams) : base(x => 
        (string.IsNullOrEmpty(specParams.Search) || x.Title.ToLower().Contains(specParams.Search) || x.Content.ToLower().Contains(specParams.Search)) &&
        (specParams.Types.Count == 0 || specParams.Types.Contains(x.Type)) &&
        (specParams.Authors.Count == 0 || specParams.Authors.Contains(x.Author))
    )
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

        switch (specParams.Sort?.ToLower())
        {
            case "alphabeticalasc":
                AddOrderBy(p => p.Title);
                break;
            case "alphabeticaldesc":
                AddOrderByDescending(p => p.Title);
                break;
            default:
                break;
        }
    }
}
