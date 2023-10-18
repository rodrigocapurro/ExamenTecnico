import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { RouterModule, Routes } from '@angular/router';
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
import { SearchBookComponent } from './search-book.component';
import { SearchBooksService } from '../../Services/search-books.service';

describe('SearchBookComponent', () => {
  let component: SearchBookComponent;
  let fixture: ComponentFixture<SearchBookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        BrowserModule,
        FormsModule, 
        ReactiveFormsModule,
        BrowserAnimationsModule,
        RouterModule,
        TableModule,
        MultiSelectModule,
        DropdownModule,
        TagModule,
        SliderModule,
        ProgressBarModule,
        InputTextModule,
        TabViewModule,
        ButtonModule,
        DialogModule,
        FieldsetModule,
        InputNumberModule
      ],
      declarations: [ SearchBookComponent ],
      providers: [SearchBooksService],
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
