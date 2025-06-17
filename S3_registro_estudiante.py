class Estudiante:
    def __init__(self, id_est, nombres, apellidos, direccion, telefonos):
        self.id = id_est
        self.nombres = nombres
        self.apellidos = apellidos
        self.direccion = direccion
        self.telefonos = telefonos  # Lista con 3 teléfonos

    def mostrar_informacion(self):
        print(f"ID: {self.id}")
        print(f"Nombres: {self.nombres}")
        print(f"Apellidos: {self.apellidos}")
        print(f"Dirección: {self.direccion}")
        print("Teléfonos:")
        for telefono in self.telefonos:
            print(f" - {telefono}")


def main():
    # Datos del estudiante
    telefonos = ["0987654321", "022345678", "0934567890"]
    estudiante = Estudiante(
        id_est=1,
        nombres="Carlos",
        apellidos="Ramírez",
        direccion="Av. Amazonas y Río Coca",
        telefonos=telefonos
    )

    # Mostrar la información
    estudiante.mostrar_informacion()


if __name__ == "__main__":
    main()
