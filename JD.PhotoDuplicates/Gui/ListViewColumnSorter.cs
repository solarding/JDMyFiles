using System.Collections;

namespace JD.PhotoDuplicates.Gui
{
    public class ListViewColumnSorter(int column, bool ascending) : IComparer
    {
        private readonly SortOrder OrderOfSort = ascending ? SortOrder.Ascending : SortOrder.Descending;
        private readonly CaseInsensitiveComparer ObjectCompare = new();
                
        public int Compare(object? x, object? y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;
            if (listviewX.SubItems.Count <= column || listviewY.SubItems.Count <= column) return 0;
            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[column].Text, listviewY.SubItems[column].Text);
                        
            if (OrderOfSort == SortOrder.Ascending)
            {            
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {             
                return -compareResult;
            }
            else
            {             
                return 0;
            }
        }
    }
}