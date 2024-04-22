defmodule FreelancerRates do
  @billable_days_in_a_month 22

  def daily_rate(hourly_rate) do
    hourly_rate * 8.0
  end

  def apply_discount(before_discount, discount) do
    before_discount * (1 - discount / 100)
  end

  def monthly_rate(hourly_rate, discount) do
    (daily_rate(hourly_rate) * @billable_days_in_a_month)
    |> apply_discount(discount)
    |> Kernel.ceil()
  end

  def days_in_budget(budget, hourly_rate, discount) do
    discounted_daily_rate =
      daily_rate(hourly_rate)
      |> apply_discount(discount)

    budget
    |> Kernel./(discounted_daily_rate)
    |> Float.floor(1)
  end
end
