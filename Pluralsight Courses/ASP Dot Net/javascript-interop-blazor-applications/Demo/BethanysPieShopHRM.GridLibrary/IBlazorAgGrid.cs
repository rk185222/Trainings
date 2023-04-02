using System.Collections.Generic;

namespace BethanysPieShopHRM.GridLibrary
{
  public interface IBlazorAgGrid
  {
    IList<ColumnDefinition> ColumnDefs { get; }
  }
}
