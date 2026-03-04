using System;
using System.IO.Pipes;

namespace Core.Specifications;

public class PostSpecParams
{
    private const int MaxPageSize = 50;
    public int PageIndex { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    private List<string> _types = [];

    public List<string> Types
    {
        get => _types;
        set
        {
            _types = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).Select(x => x.Trim()).ToList();
        }
    }

    private List<string> _authors = [];
    
    public List<string> Authors
    {
        get => _authors;
        set
        {
            _authors = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).Select(x => x.Trim()).ToList();
        }
    }

    public string ?Sort { get; set; }

    private string? _search;
    public string Search
    {
        get => _search ?? string.Empty;
        set => _search = value.ToLower();
    }
}
