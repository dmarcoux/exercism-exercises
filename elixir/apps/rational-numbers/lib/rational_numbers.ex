defmodule RationalNumbers do
  @type rational :: {integer, integer}

  @doc """
  Add two rational numbers
  """
  @spec add(rational, rational) :: rational
  def add({numerator1, denominator1}, {numerator2, denominator2}) do
    {numerator1 * denominator2 + numerator2 * denominator1, denominator1 * denominator2}
    |> reduce()
  end

  @doc """
  Subtract two rational numbers
  """
  @spec subtract(rational, rational) :: rational
  def subtract({numerator1, denominator1}, {numerator2, denominator2}) do
    {numerator1 * denominator2 - numerator2 * denominator1, denominator1 * denominator2}
    |> reduce()
  end

  @doc """
  Multiply two rational numbers
  """
  @spec multiply(rational, rational) :: rational
  def multiply({numerator1, denominator1}, {numerator2, denominator2}) do
    {numerator1 * numerator2, denominator1 * denominator2}
    |> reduce()
  end

  @doc """
  Divide two rational numbers
  """
  @spec divide_by(rational, rational) :: rational
  def divide_by({numerator1, denominator1}, {numerator2, denominator2}) do
    {numerator1 * denominator2, numerator2 * denominator1}
    |> reduce()
  end

  @doc """
  Absolute value of a rational number
  """
  @spec abs(rational) :: rational
  def abs({numerator, denominator}) do
    {Kernel.abs(numerator), Kernel.abs(denominator)}
    |> reduce()
  end

  @doc """
  Exponentiation of a rational number by an integer
  """
  @spec pow_rational(rational, n :: integer) :: rational
  def pow_rational({numerator, denominator}, n) when n > 0 do
    {Integer.pow(numerator, n), Integer.pow(denominator, n)}
    |> reduce()
  end

  def pow_rational({numerator, denominator}, n) do
    abs_n = Kernel.abs(n)

    {Integer.pow(denominator, abs_n), Integer.pow(numerator, abs_n)}
    |> reduce()
  end

  @doc """
  Exponentiation of a real number by a rational number
  """
  @spec pow_real(x :: integer, rational) :: float
  def pow_real(x, {numerator, denominator}) do
    x ** (numerator / denominator)
  end

  @doc """
  Reduce a rational number to its lowest terms
  """
  @spec reduce(rational) :: rational
  def reduce({numerator, denominator}) when denominator < 0 do
    reduce({numerator * -1, denominator * -1})
  end

  def reduce({numerator, denominator}) do
    greatest_common_divisor = Integer.gcd(numerator, denominator)

    if greatest_common_divisor > 0 do
      {div(numerator, greatest_common_divisor), div(denominator, greatest_common_divisor)}
    else
      {numerator, denominator}
    end
  end
end
