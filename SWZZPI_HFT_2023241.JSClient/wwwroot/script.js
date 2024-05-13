const menu = document.getElementById("menu");

function linker(id) {
    switch (true) {
        case id == 'champions':
            window.location.href = "./champions.html";
            break;
        case id == 'regions':
            window.location.href = "./regions.html";
            break;
        case id == 'abilities':
            window.location.href = "./abilities.html";
            break;      
        case id == 'noncruds':
            window.location.href = "./noncruds.html";
            break;
        case id == 'menu':
            window.location.href = "./index.html";
            break;
        default:
            break;
    }
}