import { Routes } from '@angular/router';
import { CategoryList } from './core/features/category/category-list/category-list';
import { AddCategory } from './core/features/category/add-category/add-category';
import { EditCategory } from './core/features/category/edit-category/edit-category';

export const routes: Routes = [
  { path: 'admin/categories', component: CategoryList },
  { path: 'admin/categories/add', component: AddCategory },
  { path: 'admin/categories/edit/:id', component: EditCategory}
];
