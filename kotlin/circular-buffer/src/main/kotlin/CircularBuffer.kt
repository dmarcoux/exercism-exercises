import kotlin.collections.ArrayDeque

class EmptyBufferException: Exception("The buffer is empty.")

class BufferFullException: Exception("The buffer is full.")

class CircularBuffer<T>(size: Int) {
    val initialCapacity: Int = size
    val array: ArrayDeque<T> = ArrayDeque(initialCapacity)

    fun read() : T {
        if (array.isEmpty()) {
            throw EmptyBufferException()
        }

        return array.removeFirst()
    }

    fun write(value: T) {
        if (array.size == initialCapacity) {
            throw BufferFullException()
        }

        array.addLast(value)
    }

    fun overwrite(value: T) {
        if (array.size == initialCapacity) {
            array.removeFirstOrNull()
        }

        write(value)
    }

    fun clear() {
        array.clear()
    }
}
