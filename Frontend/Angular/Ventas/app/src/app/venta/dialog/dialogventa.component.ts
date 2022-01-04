import { Component } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { MatDialogRef } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Concepto } from "src/app/models/concepto";
import { Venta } from "src/app/models/venta";
import { ApiventaService } from "src/app/services/apiventa.service";

@Component({
    templateUrl: 'dialogventa.component.html',  
    styleUrls: ['dialogventa.component.scss']
})
export class DialogVentaComponent {
    public venta!: Venta;
    public concepts!: Concepto[];

    public conceptoForm = this.formBuilder.group({
        cantidad: [0, Validators.required],
        importe: [0, Validators.required],
        idProducto: [1, Validators.required]
    });
    constructor(
        public dialogRef: MatDialogRef<DialogVentaComponent>,
        public snackBar: MatSnackBar,
        private formBuilder: FormBuilder,
        public apiVenta: ApiventaService
    ){
        this.concepts = [];
        this.venta = {idCliente: 1, conceptos: []};
    }

    close(){
        this.dialogRef.close();
    }

    addConcepto(){
        this.concepts.push(this.conceptoForm.value)
    }

    addVenta(){
        this.venta.conceptos = this.concepts;
        this.apiVenta.add(this.venta).subscribe(response => {
            var isExito = response.exito = 1;
            if (response.exito.toString === isExito.toString){
                this.dialogRef.close();
                this.snackBar.open("Venta realizada con éxito",
                '', {
                    duration: 2000
                });
            }
        })
    }
}