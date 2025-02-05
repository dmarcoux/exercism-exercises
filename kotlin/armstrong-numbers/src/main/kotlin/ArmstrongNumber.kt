import kotlin.math.abs
import kotlin.math.log10
import kotlin.math.pow

object ArmstrongNumber {
    val countDigits: Int.() -> Int = {
        when (this) {
            0 -> 1
            else -> log10(abs(toDouble())).toInt() + 1
        }
    }

    fun check(number: Int): Boolean {
        val digitsCount: Int = number.countDigits()
        val digits: List<Double> = number.toString().map { it.digitToInt().toDouble() }
        return number == digits.fold(0) { sum, n -> sum + n.pow(digitsCount).toInt() }
    }
}
