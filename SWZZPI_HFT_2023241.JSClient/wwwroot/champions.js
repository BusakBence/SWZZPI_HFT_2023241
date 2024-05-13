let champions = [];
let connection = null;
let championIdtoUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:30487/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("ChampionCreated", (user, message) => {
        getdata();
    });
    connection.on("ChampionDeleted", (user, message) => {
        getdata();
    });
    connection.on("ChampionUpdated", (user, message) => {
        getdata();
    });
    connection.onclose(async () => {
        await start();
    });
    start();
}
async function start() {
    try {
        await connection.start();
        console.log("SignalR connected!");
    }
    catch (e) {
        console.log(e);
        setTimeout(start, 5000);
    }
};
async function getdata() {
    await fetch("http://localhost:30487/Champions")
        .then(x => x.json())
        .then(y => {
            champions = y;
            display();
        });
}
function display() {
    console.log(champions);
    document.getElementById('resultarea').innerHTML = "";
    champions.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" + t.gender + "</td><td>" + t.species + "</td><td>" + t.lane + "</td><td>" + t.releaseYear + "</td><td>" + t.region.name + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>` + `<button type="button" onclick="showupdate(${t.id})">Update</button>` + "</td></tr>"
    })
}
function create() {
    let name = document.getElementById('Name').value;
    let gender = document.getElementById('Gender').value;
    let species = document.getElementById('Species').value;
    let lane = document.getElementById('Lane').value;
    let releaseYear = document.getElementById('ReleaseYear').value;
    let regionsId = Number(document.getElementById('RegionsId').value);
    fetch('http://localhost:30487/Champions', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, Gender: gender, Species: species, Lane: lane, ReleaseYear: releaseYear, RegionsId: regionsId }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((e) => { console.error('Error:', e); });
}

function remove(id) {
    fetch("http://localhost:30487/Champions/" + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((e) => { console.error("Error:", e); });
}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('ChampiontoUpdate').value;
    let gender = document.getElementById('GendertoUpdate').value;
    let species = document.getElementById('SpeciestoUpdate').value;
    let lane = document.getElementById('LanetoUpdate').value;
    let releaseYear = document.getElementById('ReleaseYeartoUpdate').value;
    let regionsId = Number(document.getElementById('RegionIdtoUpdate').value);
    fetch('http://localhost:30487/Champions', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Id: championIdtoUpdate, Name: name, Gender: gender, Species: species, Lane: lane, ReleaseYear: releaseYear, RegionsId: regionsId }),
    })
        .then(response => response)
        .then(data => {
            console.log("Success", data);
            getdata();
        })
        .catch((e) => { console.error('Error:', e); });
}
function showupdate(id) {
    document.getElementById('ChampiontoUpdate').value = champions.find(t => t['id'] == id)['Name'];
    document.getElementById('GendertoUpdate').value = champions.find(t => t['id'] == id)['Gender'];
    document.getElementById('SpeciestoUpdate').value = champions.find(t => t['id'] == id)['Species'];
    document.getElementById('LanetoUpdate').value = champions.find(t => t['id'] == id)['Lane'];
    document.getElementById('ReleaseYeartoUpdate').value = champions.find(t => t['id'] == id)['ReleaseYear'];
    document.getElementById('RegionIdtoUpdate').value = champions.find(t => t['id'] == id)['RegionsId'];
    document.getElementById('updateformdiv').style.display = 'flex';
    championIdtoUpdate = id;
}
