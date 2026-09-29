// El sitio ya no funciona como PWA ni en modo sin conexión.
// Este archivo reemplaza al service worker anterior en los navegadores que lo tenían
// instalado: borra sus cachés y se desregistra. No fuerza recargas para no cambiar
// la página bajo los pies de quien está leyendo; la siguiente visita ya llega limpia.
// Puede eliminarse cuando hayan pasado algunos meses.
self.addEventListener('install', () => self.skipWaiting());

self.addEventListener('activate', event => {
    event.waitUntil((async () => {
        const claves = await caches.keys();
        await Promise.all(claves
            .filter(clave => clave.startsWith('offline-cache-'))
            .map(clave => caches.delete(clave)));
        await self.registration.unregister();
    })());
});
