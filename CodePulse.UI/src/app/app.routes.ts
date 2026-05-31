import { Routes } from '@angular/router';
import { CategoryList } from './core/features/category/category-list/category-list';
import { AddCategory } from './core/features/category/add-category/add-category';

export const routes: Routes = [
  { path: 'admin/categories', component: CategoryList },
  { path: 'admin/categories/add', component: AddCategory}
];
