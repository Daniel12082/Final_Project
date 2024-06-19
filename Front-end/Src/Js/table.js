var frontendURL = window.location.href;
const segments = frontendURL.split('/');
let lastSegment = segments.pop() || segments.pop(); // Obtiene la última parte de la URL
if (lastSegment.endsWith('.html')) {
    lastSegment = lastSegment.slice(0, -5); // Elimina los últimos 5 caracteres (.html)
}

const backendBaseURL = "http://localhost:5019";
const endpointUrl = `${backendBaseURL}/${lastSegment}`; // Construye la URL del endpoint

fetch(endpointUrl)
    .then(response => {
        if (!response.ok) {
            throw new Error('Error al obtener los datos');
        }
        return response.json();
    })
    .then(users => {
        // Obtener las claves (nombres de las columnas) del primer objeto en el array
        const keys = Object.keys(users[0]);
        
        // Filtrar las claves que no son arrays ni contienen la palabra "Navigation"
        const filteredKeys = keys.filter(key => {
            return !users.some(item => Array.isArray(item[key])) && !key.includes('Navigation');
        });

        // Obtener la referencia a la tabla en el HTML
        const table = document.getElementById('example');
        
        // Crear el encabezado de la tabla (thead)
        const thead = table.createTHead();
        const headerRow = thead.insertRow();
        filteredKeys.forEach(key => {
            const th = document.createElement('th');
            th.textContent = key;
            headerRow.appendChild(th);
        });
        
        // Crear el cuerpo de la tabla (tbody) y llenar los datos
        const tbody = table.createTBody();
        users.forEach(item => {
            const row = tbody.insertRow();
            filteredKeys.forEach(key => {
                const cell = row.insertCell();
                cell.textContent = item[key];
            });
        });
        
        // Configurar DataTables con la cantidad de registros por página
        $(document).ready(function () {
            $('#example').DataTable({
                "pageLength": 7 // Aquí se especifica el número de registros por página
            });
            
        });
    })
    .catch(error => {
        console.error('Error:', error);
        // Manejar errores y mostrar mensaje de error al usuario
    });