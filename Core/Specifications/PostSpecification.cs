using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class PostSpecification : BaseSpecification<Post>
{
    public PostSpecification(string? type, string? author, string? sort) : base(p => 
        (string.IsNullOrEmpty(type) || p.Type == type) &&
        (string.IsNullOrEmpty(author) || p.Author == author))
    {
        switch (sort?.ToLower())
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
  