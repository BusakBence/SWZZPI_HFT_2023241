let shurimachampionsarray = [];
let femalesultimatesarray = [];
let ionianchampionsarray = [];
let demacianabilitiesarray = [];
let dchampionspabilitiesarray = [];
let morethantwolanesarray = [];
shurimachampions();
femalesultimates();
ionianchampions();
demacianabilities();
dchampionspabilities();
morethantwolanes();

async function shurimachampions() {
    await fetch('http://localhost:30487/Stat/GetShurimaChampionsBetween2012And2016/')
        .then(x => x.json())
        .then(y => {
            shurimachampionsarray = y;
            console.log(shurimachampionsarray);
            displayshurimachampions();
        });
}

function displayshurimachampions() {
    document.getElementById('shurimachampions').innerHTML = "";
    shurimachampionsarray.forEach(t => {
        document.getElementById('shurimachampions').innerHTML += "<tr><td>" + t.name + "</td><td>" + t.region + "</td><td>" + t.year + "</td></tr>";
    });
}
async function femalesultimates() {
    await fetch('http://localhost:30487/Stat/GetFemalesUltimates/')
        .then(x => x.json())
        .then(y => {
            femalesultimatesarray = y;
            console.log(femalesultimatesarray);
            displayfemalesultimates();
        });
}
function displayfemalesultimates() {
    document.getElementById('femalesultimates').innerHTML = "";
    femalesultimatesarray.forEach(t => {
        document.getElementById('femalesultimates').innerHTML += "<tr><td>" + t.name + "</td><td>" + t.abilityName + "</td></tr>";
    });
}
async function ionianchampions() {
    await fetch('http://localhost:30487/Stat/GetAllIonianChampions/')
        .then(x => x.json())
        .then(y => {
            ionianchampionsarray = y;
            console.log(ionianchampionsarray);
            displayionianchampions();
        });
}

function displayionianchampions() {
    document.getElementById('ionianchampions').innerHTML = "";
    ionianchampionsarray.forEach(t => {
        document.getElementById('ionianchampions').innerHTML += "<tr><td>" + t.name + "</td><td>" + t.region + "</td></tr>";
    });
}
async function demacianabilities() {
    await fetch('http://localhost:30487/Stat/GetDemacianAbilities/')
        .then(x => x.json())
        .then(y => {
            demacianabilitiesarray = y;
            console.log(demacianabilitiesarray);
            displaydemacianabilities();
        });
}

function displaydemacianabilities(id) {
    document.getElementById('demacianabilities').innerHTML = "";
    demacianabilitiesarray.forEach(t => {
        document.getElementById('demacianabilities').innerHTML += "<tr><td>" + t.championName + "</td><td>" + t.name + "</td><td>" + t.region + "</td><td>" + t.key + "</td></tr>";
    });
}
async function dchampionspabilities() {
    await fetch('http://localhost:30487/Stat/GetDChampionsPAbilities/')
        .then(x => x.json())
        .then(y => {
            dchampionspabilitiesarray = y;
            console.log(dchampionspabilitiesarray);
            displaydchampionspabilities();
        });
}
function displaydchampionspabilities() {
    document.getElementById('dchampionspabilities').innerHTML = "";
    dchampionspabilitiesarray.forEach(t => {
        document.getElementById('dchampionspabilities').innerHTML += "<tr><td>" + t.name + "</td><td>" + t.key + "</td><td>" + t.keyName + "</td></tr>";
    });
}
async function morethantwolanes() {
    await fetch('http://localhost:30487/Stat/GetMoreThanTwoLanes/')
        .then(x => x.json())
        .then(y => {
            morethantwolanesarray = y;
            console.log(morethantwolanesarray);
            displaymorethantwolanes();
        });
}
function displaymorethantwolanes() {
    document.getElementById('morethantwolanes').innerHTML = "";
    morethantwolanesarray.forEach(t => {
        document.getElementById('morethantwolanes').innerHTML += "<tr><td>" + t.name + "</td><td>" + t.lane + "</td><td>" + t.region + "</td></tr>";
    });
}