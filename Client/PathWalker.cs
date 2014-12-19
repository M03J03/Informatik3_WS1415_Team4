using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonsAndRabbits.Manager;

namespace DragonsAndRabbits.Client
{
   public class PathWalker
    {
       private Manager.Manager mgr = Manager.Manager.getManger();
       public PathWalker()
       {
           Player p = new Player();
           p.playerPoints += observerPlayer;
           p.setPoints(1);
       }

       public void observerPlayer(object sender, EventArgs e)
       {

           Console.WriteLine("------------------------------------WORKS???-------------------");

           foreach (Player p in mgr.getPlayers())
           {
               Console.WriteLine("------------------------------------WORKS???-------------------");
           }
       }

    }



    




}
