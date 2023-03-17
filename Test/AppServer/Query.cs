using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.AppServer
{
    public class Query
    {
        public const string ProcedureStreet = @"CREATE PROCEDURE InsertStreet 
as BEGIN 
INSERT INTO [dbo].[Streets] (ID,Street_Name,ID_City)
VALUES (@ID,@Street,@ID_City)
END ";
        public const string InsertCity = @"INSERT INTO [dbo].[Cities] (ID,City_Name)
VALUES (@ID,@City)";
        public const string DeleteCity = @" DELETE FROM [dbo].[Cities]
   WHERE ID LIKE @ID";
        public const string GetStreets = @" SELECT * FROM [dbo].[Streets]
LEFT JOIN [dbo].[Cities]
ON [Streets].[ID_City]=[Cities].[ID]
WHERE [Cities].[ID] LIKE @IDCity";
    }
   

}
