
import axios from 'axios';
import type { Student } from '../models/Student';

const API_URL = 'http://localhost:5236/api/Student'; 

export const getStudents = () => axios.get<Student[]>(API_URL);
export const getStudentById = (id: number) => axios.get<Student>(`${API_URL}/${id}`);
export const createStudent = (student: Student) => axios.post(API_URL, student);
export const updateStudent = (student: Student) => axios.put(`${API_URL}/${student.id}`, student);
export const deleteStudent = (id: number) => axios.delete(`${API_URL}/${id}`);

