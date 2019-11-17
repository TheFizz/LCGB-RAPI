using RiotNet;
using RiotNet.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LCGB
{
    class Client
    {
        private IRiotClient _client;

        public void InitializeClient()
        {
            _client = new RiotClient(new RiotClientSettings
            {
                ApiKey = LCGB.Key.apikey
            });
        }
        public Summoner GetSummoner(string nickname, string server)
        {
            Summoner summoner = _client.GetSummonerBySummonerNameAsync(nickname, server).Result;
            if (summoner != null)
                return summoner;
            else
            {
                MessageBox.Show("Summoner not found. Maybe another server?", "ERROR");
                return summoner;
            }
        }
        public LeagueEntry GetLeaguePosition(string summonerId, string server)
        {
            List<LeagueEntry> leagues = _client.GetLeagueEntriesBySummonerIdAsync(summonerId, server).Result;
            foreach(LeagueEntry league in leagues)
            {
                if (league.QueueType == "RANKED_SOLO_5x5")
                {
                    return league;
                }
            }
            return null;
        }
        public string LastRank(string accountId, string server)
        {
            MatchList matchList = _client.GetMatchListByAccountIdAsync(accountId,null, null, null, null, null, null, null, server).Result;
            if(matchList==null)
            {
                return null;
            }
            Match match = _client.GetMatchAsync(matchList.Matches[0].GameId,server).Result;
            if(match==null)
            {
                return null;
            }
            int partId = -1;
            foreach(MatchParticipantIdentity identity in match.ParticipantIdentities)
            {
                if(identity.Player.AccountId==accountId)
                {
                    partId = identity.ParticipantId;
                }
            }
            foreach(MatchParticipant participant in match.Participants)
            {
                if (participant.ParticipantId == partId)
                    return participant.HighestAchievedSeasonTier;
            }
            return null;
        }
    }
}
