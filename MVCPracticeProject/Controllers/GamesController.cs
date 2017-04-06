using System;
using System.Web.Mvc;
using MVCPracticeProject.Models;

namespace MVCPracticeProject.Controllers
{
    public class GamesController : Controller
    {
        public ActionResult Sukudo()
        {
            return View();
        }

        public ActionResult SukudoCheckBoard(string boardValue)
        {
            string[] temp = new string[] { };
            bool fullState = true;
            temp = boardValue.Split(',');
            int size = (int)Math.Sqrt(temp.Length);
            int[,] board = new int[size, size];
            int n = 0;
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    board[i, k] = int.Parse(temp[n]);
                    if (board[i, k] == 0) fullState = false;
                    n++;
                }
            }
            SukudoBoardVerifyModel boardModule = new SukudoBoardVerifyModel(board);
            bool verify = boardModule.verify();
            if (verify == true && fullState == true) ViewBag.message = "3";
            else
            {
                if (verify == true) ViewBag.message = "1";
                else ViewBag.message = "2";
            }
            return View();
        }
    }
}