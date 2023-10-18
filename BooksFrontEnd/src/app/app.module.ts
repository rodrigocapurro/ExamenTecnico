import { NgModule, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

import { AppRoutingModule } from './app-routing.module';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { TableModule } from 'primeng/table';
import { MultiSelectModule } from 'primeng/multiselect';
import { DropdownModule } from 'primeng/dropdown';
import { TagModule } from 'primeng/tag';
import { SliderModule } from 'primeng/slider';
import { ProgressBarModule } from 'primeng/progressbar';
import { InputTextModule } from 'primeng/inputtext';
import { TabViewModule } from 'primeng/tabview';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { FieldsetModule } from 'primeng/fieldset';
import { InputNumberModule } from 'primeng/inputnumber';
import { SearchBookComponent } from './Components/search-book/search-book.component';
import { SearchBooksService } from './Services/search-books.service';
import { TableFilteredComponent } from './Components/Tables/table-filtered/table-filtered.component';

@NgModule({
  declarations: [
    SearchBookComponent,
    TableFilteredComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    TableModule,
    MultiSelectModule,
    DropdownModule,
    TagModule,
    SliderModule,
    ProgressBarModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    InputTextModule,
    TabViewModule,
    ButtonModule,
    DialogModule,
    FieldsetModule,
    InputNumberModule,
    RouterModule.forRoot([{ path: '', component: SearchBookComponent }])
  ],
  providers: [SearchBooksService],
  bootstrap: [SearchBookComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA], 
})
export class AppModule { }
