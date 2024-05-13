let abilities = [];
let connection = null;
let abilityIdtoUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:30487/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("AbilityCreated", (user, message) => {
        getdata();
    });
    connection.on("AbilityDeleted", (user, message) => {
        getdata();
    });
    connection.on("AbilityUpdated", (user, message) => {
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
    await fetch("http://localhost:30487/Abilities")
        .then(x => x.json())
        .then(y => {
            abilities = y;
            display();
        });
}
function display() {
    console.log(abilities);
    document.getElementById('resultarea').innerHTML = "";
    abilities.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" + t.abilityKey + "</td><td>" + t.champion.name +  "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>` + `<button type="button" onclick="showupdate(${t.id})">Update</button>` + "</td></tr>"
    })
}
function create() {
    let name = document.getElementById('Name').value;
    let abilityKey = document.getElementById('AbilityKey').value;
    let championId = Number(document.getElementById('ChampionId').value);
    fetch('http://localhost:30487/Abilities', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, AbilityKey: abilityKey, ChampionId: championId }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((e) => { console.error('Error:', e); });
}

function remove(id) {
    fetch("http://localhost:30487/Abilites/" + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((e) => { console.error("Error:", e);});
}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('AbilitytoUpdate').value;
    let abilityKey = document.getElementById('KeytoUpdate').value;
    let champion = Number(document.getElementById('ChampionIdtoUpdate').value);
    fetch('http://localhost:30487/Abilities', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Id: abilityIdtoUpdate, Name: name, AbilityKey: abilityKey, Champion: champion.name }),
    })
            .then(response => response)
            .then(data => {
                console.log("Success", data);
                getdata();
            })
            .catch((e) => { console.error('Error:', e);});   
}
function showupdate(id) {
    document.getElementById('AbilitytoUpdate').value = abilities.find(t => t['id'] == id)['Name'];
    document.getElementById('KeytoUpdate').value = abilities.find(t => t['id'] == id)[char.parse('AbilityKey')];
    document.getElementById('ChampionIdtoUpdate').value = Number(abilities.find(t => t['id'] == id)['ChampionId']);
    document.getElementById('updateformdiv').style.display = 'flex';
    abilityIdtoupdate = id;
}
