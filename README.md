# Coordinate Conversion Strategies

Этот файл описывает формулы для преобразования координат между различными системами координат: Декартовой, Сферической, Цилиндрической и Полярной.

## Формулы преобразования координат

### 1. Декартовы (x, y, z) → Сферические (r, θ, φ)
\[
r = \sqrt{x^2 + y^2 + z^2}, \quad \theta = \arccos\left(\frac{z}{r}\right), \quad \phi = \arctan2(y, x)
\]

### 2. Декартовы (x, y, z) → Цилиндрические (ρ, φ, z)
\[
ρ = \sqrt{x^2 + y^2}, \quad φ = \arctan2(y, x), \quad z = z
\]

### 3. Декартовы (x, y) → Полярные (ρ, θ)
\[
ρ = \sqrt{x^2 + y^2}, \quad θ = \arctan2(y, x)
\]

### 4. Сферические (r, θ, φ) → Декартовы (x, y, z)
\[
x = r \sin(θ) \cos(φ), \quad y = r \sin(θ) \sin(φ), \quad z = r \cos(θ)
\]

### 5. Сферические (r, θ, φ) → Цилиндрические (ρ, φ, z)
\[
ρ = r \sin(θ), \quad φ = φ, \quad z = r \cos(θ)
\]

### 6. Сферические (r, θ, φ) → Полярные (ρ, θ)
\[
ρ = r \sin(θ), \quad θ = φ
\]

### 7. Цилиндрические (ρ, φ, z) → Декартовы (x, y, z)
\[
x = ρ \cos(φ), \quad y = ρ \sin(φ), \quad z = z
\]

### 8. Цилиндрические (ρ, φ, z) → Сферические (r, θ, φ)
\[
r = \sqrt{ρ^2 + z^2}, \quad θ = \arctan2(ρ, z), \quad φ = φ
\]

### 9. Цилиндрические (ρ, φ, z) → Полярные (ρ, θ)
\[
ρ = ρ, \quad θ = φ
\]

### 10. Полярные (ρ, θ) → Декартовы (x, y)
\[
x = ρ \cos(θ), \quad y = ρ \sin(θ)
\]

### 11. Полярные (ρ, θ) → Сферические (r, θ, φ)
\[
r = ρ, \quad θ = θ, \quad φ = 0
\]

### 12. Полярные (ρ, θ) → Цилиндрические (ρ, φ, z)
\[
ρ = ρ, \quad φ = θ, \quad z = 0
\]

## Описание

Эти формулы помогают преобразовывать координаты из одной системы координат в другую для различных задач, связанных с математикой, физикой и компьютерным моделированием.
