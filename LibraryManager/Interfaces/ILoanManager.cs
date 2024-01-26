using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Interfaces
{
    public interface ILoanManager {
        public void LoanBook(int bookId, int userId);

        public void ReturnBook(int bookId, int userId);
    }
}
