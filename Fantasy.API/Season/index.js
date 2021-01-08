module.exports = async function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request for Season.');

    // importing ff node package
    const { Client } = require('../espn-fantasy-api.js');
    context.log('ESPNFantasyAPI imported.');

    const SEASON_ID = context.bindingData.seasonId; //2020
    const LEAGUE_ID = context.bindingData.leagueId; //551600, 1246423
    const SWID = process.env["COOKIE_SWID"];
    const ESPNSS2 = process.env["COOKIE_ESPNS2"];

    // Creating client
    const myClient = new Client({ leagueId: LEAGUE_ID });
    context.log('ESPNFantasyAPI Client established.');

    // Setting session cookies, this is required if your league is private
    myClient.setCookies({ espnS2: ESPNSS2, SWID: SWID });
    context.log('ESPNFantasyAPI Client cookies set.');

    try {
        const getLeagueResult = await myClient.getMatchupScores({ seasonId: SEASON_ID });
        context.log(`API call finished, result - ${getLeagueResult.name}`);

        return {
            // status: 200, /* Defaults to 200 */
            body: getLeagueResult
        };
    }
    catch (err) {
        context.log.error('ERROR', err);
        // This rethrown exception will be handled by the Functions Runtime and will only fail the individual invocation
        throw err;
    }
}