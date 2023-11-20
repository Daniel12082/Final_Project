const body = document.querySelector("body"),
    modeToggle = body.querySelector(".mode-toggle"),
    sidebar = body.querySelector("nav"),
    sidebarToggle = body.querySelector(".sidebar-toggle");

let getMode = localStorage.getItem("mode");

function applyDarkModeStyles() {
    const buttonsInBox1 = document.querySelectorAll('.box_1 button');
    const buttonsInBox2 = document.querySelectorAll('.box button');
    buttonsInBox2.forEach(button => {
        button.style.backgroundColor = 'var(--title-icon-color)';
    });
    buttonsInBox1.forEach(button => {
        button.style.backgroundColor = 'var(--title-icon-color)';
    });
}

function applyLightModeStyles() {
    const buttonsInBox1 = document.querySelectorAll('.box_1 button');
    const buttonsInBox2 = document.querySelectorAll('.box button');
    buttonsInBox2.forEach(button => {
        button.style.backgroundColor = 'var(--primary-color)';
    });
    buttonsInBox1.forEach(button => {
        button.style.backgroundColor = 'var(--primary-color)';
    });
}

if (getMode === "dark") {
    body.classList.add("dark");
    applyDarkModeStyles();
} else if (getMode === "light") {
    body.classList.add("light");
    applyLightModeStyles();
}

let getStatus = localStorage.getItem("status");
if(getStatus && getStatus ==="close"){
    sidebar.classList.toggle("close");
}

sidebarToggle.addEventListener("click", () => {
    sidebar.classList.toggle("close");
    if(sidebar.classList.contains("close")){
        localStorage.setItem("status", "close");
    }else{
        localStorage.setItem("status", "open");
    }
})
modeToggle.addEventListener("click", function () {
    if (body.classList.contains("dark")) {
        body.classList.remove("dark");
        body.classList.add("light");
        applyLightModeStyles();
        localStorage.setItem("mode", "light");
    } else {
        body.classList.remove("light");
        body.classList.add("dark");
        applyDarkModeStyles();
        localStorage.setItem("mode", "dark");
    }
})
