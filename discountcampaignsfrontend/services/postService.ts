// services/postService.ts
import { DiscountRequest } from '@/app/page';
import api from '../lib/api';

export interface Product {
    name: string;
    category: string;
    price: number;
}

export async function getProducts(): Promise<Product[]> {
  const res = await api.get<Product[]>('/Products/GetProducts');
  return res.data;
}

export async function calculateTotalSum( discountRequestDto : DiscountRequest): Promise<number> {
  const res = await api.post<number>('/Products/CalculateTotalSum', discountRequestDto);
  return res.data;
}
