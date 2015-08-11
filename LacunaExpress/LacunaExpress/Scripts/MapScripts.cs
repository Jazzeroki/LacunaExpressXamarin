using LacunaExpanseAPIWrapper;
using LacunaExpanseAPIWrapper.ResponseModels;
using LacunaExpress.AccountManagement;
using LacunaExpress.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpress.Scripts
{
    class MapScripts
    {
        public static async Task<List<Stars>> GetAllBodiesInRange30(AccountModel account, int x, int y)
        {
            int x1, x2, y1, y2;
            x1 = x - 15;
            x2 = x + 15;
            y1 = y - 15;
            y2 = y + 15;
            //Map map = new Map();
            var json = Map.GetStars(account.SessionID, Convert.ToString(x1), Convert.ToString(y1), Convert.ToString(x2), Convert.ToString(y2));
            var server = new LacunaExpress.Data.Server();
            var reply = await server.GetHttpResultAsync(account.Server, Map.URL, json);
            if (reply.result != null)
            {
                return reply.result.stars;
            }
            else
                return null;
        }
        public static async Task<List<Stars>> GetAllStarsInRange300(AccountModel account, int x, int y)
        {
            int max, min;
            max = 1500;
            min = -1500;

            int startX, endX, startY, endY, maxRangePerRequest;
            maxRangePerRequest = 30;


            //setting initial x range values
            startX = x - 150;
            startX = CheckMaxMinAt1500(startX);
            endX = x + 150;
            endX = CheckMaxMinAt1500(endX);

            //setting initial y range values
            startY = y + 150;
            startY = CheckMaxMinAt1500(startY);
            endY = y - 150;
            endY = CheckMaxMinAt1500(endY);


            int xStart30 = startX;
            int yStart30 = startY;
            int xEnd30 = startX + 30;
            int yEnd30 = startY - 30;
            bool keepgoing = true;
            List<ThrottledServerRequest> requests = new List<ThrottledServerRequest>();
            do
            {
                if (xEnd30 > endX)
                    xEnd30 = endX;
                var json = Map.GetStars(account.SessionID, xStart30.ToString(), yStart30.ToString(), xEnd30.ToString(),  yEnd30.ToString());
                var request = new ThrottledServerRequest(account.Server, Map.URL, json);
                requests.Add(request);

                //increasing counter but being warry of map edges
                
                if (xEnd30 >= endX)
                {
                    xEnd30 = endX;
                    xStart30 = startX;
                    xEnd30 = xStart30 + 30;
                    yStart30 = yEnd30;
                    yEnd30 -= 30;
                    if (yEnd30 < endY)
                        yEnd30 = endY;
                }
                else
                {
                    xStart30 = xEnd30;
                    xEnd30 += 30;
                }

                if (xEnd30 == endX && yEnd30 == endY)
                    keepgoing = false;
                               
            } while (keepgoing);
            var responses = await LacunaExpress.Data.Server.ThrottledServerReturns(requests);

            List<Stars> stars = new List<Stars>();
            foreach(var response in responses)
            {
                if(response.result != null)
                {
                    foreach (var star in response.result.stars)
                        stars.Add(star);
                }
            }

            if (stars.Count > 0)
                return stars.Distinct().ToList();
            else
                return null;
        }
        //static List<Stars> GetAllBodiesInRange(int centerx, int centery, int range){
        //	//method to support getting stars by a much larger range still in development

        //	int x1, x2, y1, y2;
        //	x1 = centerx-15;
        //	x2 = centerx+15;
        //	y1 = centery-15;
        //	y2 = centery+15;
        //	//Map map = new Map();
        //	String request = map.GetStars(sessionID, Integer.toString(x1), Integer.toString(y1), Integer.toString(x2), Integer.toString(y2));
        //	String reply = server.ServerRequest(gameServer, map.url, request);
        //	Response r = gson.fromJson(reply, Response.class);
        //	return r.result.stars;
        //}
        private static int CheckMaxMinAt1500(int coordinate)
        {
            var x = coordinate;
            int max, min;
            max = 1500;
            min = -1500;
            if (coordinate > max)
                x = max;
            if (coordinate < min)
                x = min;
            return x;
        }
        static bool CheckSystemHostile(List<Bodies> bodies)
        {

            foreach (var b in bodies)
            {
                if (b.empire != null)
                {
                    if (b.empire.alignment.Equals("hostile"))
                        return true;
                }
            }
            return false;
        }
    }
}
