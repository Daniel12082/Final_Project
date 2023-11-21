var frontendURL = window.location.href;
const segments = frontendURL.split('/');
let lastSegment = segments.pop() || segments.pop();
if (lastSegment.endsWith('.html')) {
    lastSegment = lastSegment.slice(0, -5); // Eliminar los últimos 5 caracteres (.html)
}
const backendBaseURL = "http://localhost:5019";
const endpointUrl = `${backendBaseURL}/${lastSegment}`; // Reemplaza con tu URL correcta
fetch(endpointUrl)
    .then(response => {
        if (!response.ok) {
            throw new Error('Error al obtener los usuarios');
        }
        return response.json();
    })
    .then(users => {
        const keys = Object.keys(users[0]);
        
        // Filtrar las columnas que no son arrays ni tienen "Navigation"
        const filteredKeys = keys.filter(key => {
            return !users.some(item => Array.isArray(item[key])) && !key.includes('Navigation');
        });

        const table = document.getElementById('example');
        
        // Crear el encabezado (thead)
        const thead = table.createTHead();
        const headerRow = thead.insertRow();
        filteredKeys.forEach(key => {
            const th = document.createElement('th');
            th.textContent = key;
            headerRow.appendChild(th);
        });
        
        // Crear el cuerpo (tbody) y llenar la tabla, omitiendo las columnas que son arrays o contienen "Navigation"
        const tbody = table.createTBody();
        users.forEach(item => {
            const row = tbody.insertRow();
            filteredKeys.forEach(key => {
                const cell = row.insertCell();
                cell.textContent = item[key];
            });
        });

        // Inicializar DataTables después de llenar la tabla
        $(document).ready(function () {
            $('#example').DataTable();
        });
    })
    .catch(error => {
        // Manejar errores y mostrar mensaje de error
        console.error(error.message);
    });