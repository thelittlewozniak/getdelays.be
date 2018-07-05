using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDelaysAPI
{
    public interface IAPI
    {
        User GetUser(string email);
        User Login(string email, string password);
        User MakeAccount(string email, string name, string surname, string password, string phoneNumber);
        bool DeleteUser(User user);
        User UpdateUser(string email, string name, string surname, string phoneNumber, User user);
        User FollowStation(string station, User user);
        User DeleteFollowStation(string station, User user);
        List<StationData> SearchStation();
        Station GetStationsByName(string station);
        Train GetTrain(string idTrain);
        Train GetTrainFromStation(string idTrain, string StationName);
        List<Connection> GetConnection(string dep, string arr);
        List<NotificationStation> GetNotificationStations(User user);
    }
}
