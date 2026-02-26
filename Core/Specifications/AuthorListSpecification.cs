using System;
using System.Net.Http.Headers;
using Core.Entities;

namespace Core.Specifications;

public class AuthorListSpecification : BaseSpecification<Post, string>
{
    public AuthorListSpecification()
    {
        AddSelect(p => p.Author);
        ApplyDistinct();
    }
}
