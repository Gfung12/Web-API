const express = require('express');
const app = express();


app.use(express.json());


let lista = {
  cabeza: null,
  agregar(valor) {
    const jugueteNuevo = {
      id: Math.random().toString(36).substring(2), // ID mágico
      valor: valor,
      siguiente: null
    };
    if (!this.cabeza) {
      this.cabeza = jugueteNuevo;
    } else {
      let jugueteActual = this.cabeza;
      while (jugueteActual.siguiente) {
        jugueteActual = jugueteActual.siguiente;
      }
      jugueteActual.siguiente = jugueteNuevo;
    }
    return jugueteNuevo.id;
  },
  eliminar(id) {
    if (!this.cabeza) return false;
    if (this.cabeza.id === id) {
      this.cabeza = this.cabeza.siguiente;
      return true;
    }
    let jugueteActual = this.cabeza;
    while (jugueteActual.siguiente) {
      if (jugueteActual.siguiente.id === id) {
        jugueteActual.siguiente = jugueteActual.siguiente.siguiente;
        return true;
      }
      jugueteActual = jugueteActual.siguiente;
    }
    return false;
  },
  listar() {
    const juguetes = [];
    let jugueteActual = this.cabeza;
    while (jugueteActual) {
      juguetes.push({ id: jugueteActual.id, valor: jugueteActual.valor });
      jugueteActual = jugueteActual.siguiente;
    }
    return juguetes;
  }
};

// 5. Los "botones" del servidor (GET, POST, DELETE)
app.get('/linked-list', (req, res) => {
  res.json(lista.listar());
});

app.post('/linked-list', (req, res) => {
  const id = lista.agregar(req.body.value);
  res.json({ id });
});

app.delete('/linked-list/:id', (req, res) => {
  const eliminado = lista.eliminar(req.params.id);
  if (eliminado) {
    res.status(204).end();
  } else {
    res.status(404).end();
  }
});

// 6. Encendemos el servidor (como prender un robot)
const PORT = 3000;
app.listen(PORT, () => {
  console.log(`Servidor corriendo en http://localhost:${PORT}`);
});