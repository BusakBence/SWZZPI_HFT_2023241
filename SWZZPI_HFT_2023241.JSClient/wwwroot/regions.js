let regions = [];
let connection = null;
let regionIdtoUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:30487/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("RegionsCreated", (user, message) => {
        getdata();
    });
    connection.on("RegionsDeleted", (user, message) => {
        getdata();
    });
    connection.on("RegionsUpdated", (user, message) => {
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
    await fetch("http://localhost:30487/Regions")
        .then(x => x.json())
        .then(y => {
            regions = y;
            display();
        });
}
function display() {
    console.log(regions);
    document.getElementById('resultarea').innerHTML = "";
    regions.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" + t.location + "</td><td>" + t.technologyLevel + "</td><td>" + t.formOfGovernment + "</td><td>" + t.environment + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>` + `<button type="button" onclick="showupdate(${t.id})">Update</button>` + "</td></tr>"
    })
}
function create() {
    let name = document.getElementById('Name').value;
    let location = document.getElementById('Location').value;
    let technologyLevel = document.getElementById('TechnologyLevel').value;
    let formOfGovernment = document.getElementById('FormOfGovernment').value;
    let environment = document.getElementById('Environment').value;
    fetch('http://localhost:30487/Regions', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, Location: location, TechnologyLevel: technologyLevel, FormOfGovernment: formOfGovernment, Environment: environment }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((e) => { console.error('Error:', e); });
}

function remove(id) {
    fetch("http://localhost:30487/Regions/" + id, {
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
    let name = document.getElementById('RegiontoUpdate').value;
    let location = document.getElementById('LocationtoUpdate').value;
    let technologyLevel = document.getElementById('TLtoUpdate').value;
    let formOfGovernment = document.getElementById('FOGtoUpdate').value;
    let environment = document.getElementById('EnvironmenttoUpdate').value;
    fetch('http://localhost:30487/Regions', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Id: regionIdtoUpdate, Name: name, Location: location, TechnologyLevel: technologyLevel, FormOfGovernment: formOfGovernment, Environment: environment }),
    })
        .then(response => response)
        .then(data => {
            console.log("Success", data);
            getdata();
        })
        .catch((e) => { console.error('Error:', e); });
}
function showupdate(id) {    
    document.getElementById('RegiontoUpdate').value = regions.find(t => t['id'] == id)['Name'];
    document.getElementById('LocationtoUpdate').value = regions.find(t => t['id'] == id)['Location'];
    document.getElementById('TLtoUpdate').value = regions.find(t => t['id'] == id)['TechnologyLevel'];
    document.getElementById('FOGtoUpdate').value = regions.find(t => t['id'] == id)['FormOfGovernment'];
    document.getElementById('EnvironmenttoUpdate').value = regions.find(t => t['id'] == id)['Environment'];
    document.getElementById('updateformdiv').style.display = 'flex';
    regionIdtoUpdate = id;
}
