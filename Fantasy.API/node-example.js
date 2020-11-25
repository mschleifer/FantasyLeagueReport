// run w/ 'node node-example.js' from a terminal in the project folder
// works while a JS in the browser version does not

// importing ff node package
const { Client } = require('espn-fantasy-football-api/node');

const SEASON_ID = 2020;
const LEAGUE_ID = 551600
const SWID = 'REDACTED';
const ESPNSS2 = 'REDACTED';

// Creating client
const C = new Client({ leagueId: LEAGUE_ID });

// Setting session cookies, this is required if your league is private
C.setCookies({ espnS2: ESPNSS2, SWID: SWID });

// Gathering league info using season ID
C.getLeagueInfo({ seasonId: SEASON_ID }).then(response => {
    console.log({ response });
    // do stuff with data
}).catch(error => {
    console.log({ error });
    // what went wrong
})