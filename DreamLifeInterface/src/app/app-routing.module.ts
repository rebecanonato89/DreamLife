import { Routes, RouterModule } from '@angular/router';
import { CadastrarcidadeComponent } from '../app/body/cadastrarcidade/cadastrarcidade.component';
import { CadastrarhotelComponent } from '../app/body/cadastrarhotel/cadastrarhotel.component';
import { BodyComponent } from '../app/body/body.component';
import { NgModule } from '@angular/core';


const appRoutes: Routes = [
  { path: '', component: BodyComponent },
  { path: 'Home', component: BodyComponent },
  { path: 'CadastrarCidade', component: CadastrarcidadeComponent },
  { path: 'CadastrarHotel', component: CadastrarhotelComponent },
];

// export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(appRoutes)],
})

export class AppRoutingModule { }
