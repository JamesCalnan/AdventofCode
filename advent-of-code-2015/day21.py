from collections import namedtuple

BOSS_HIT_POINTS = 104
BOSS_DAMAGE = 8
BOSS_ARMOR = 1

Item = namedtuple('Item', ['name', 'cost', 'dmg', 'armor'])

WEAPONS = [
    Item('Dagger',        8,     4,       0),
    Item('Shortsword',   10,     5,       0),
    Item('Warhammer',    25,     6,       0),
    Item('Longsword',    40,     7,       0),
    Item('Greataxe',     74,     8,       0),
]
ARMOR = [
    Item('Nothing',       0,     0,       0),
    Item('Leather',      13,     0,       1),
    Item('Chainmail',    31,     0,       2),
    Item('Splintmail',   53,     0,       3),
    Item('Bandedmail',   75,     0,       4),
    Item('Platemail',   102,     0,       5),
]

RINGS = [
    Item('Nothing 1',     0,     0,       0),
    Item('Nothing 2',     0,     0,       0),
    Item('Damage +1',    25,     1,       0),
    Item('Damage +2',    50,     2,       0),
    Item('Damage +3',   100,     3,       0),
    Item('Defense +1',   20,     0,       1),
    Item('Defense +2',   40,     0,       2),
    Item('Defense +3',   80,     0,       3),
]

def doesPlayerWin(HP, damage, armor):

  lossPerTurnBoss = damage - BOSS_ARMOR

  if lossPerTurnBoss < 1:
    lossPerTurnBoss = 1

  lossPerTurnPlayer = BOSS_DAMAGE - armor

  if lossPerTurnPlayer < 1:
    lossPerTurnPlayer = 1

  n, r = divmod(BOSS_HIT_POINTS, lossPerTurnBoss)

  if r == 0:
    n -= 1
  
  if lossPerTurnPlayer * n >= HP:
    return False

  return True

def solve():
  minCost = 10000
  maxCost = 0

  for weapon in WEAPONS:
    for armor in ARMOR:
      for ring1 in RINGS:
        for ring2 in RINGS:

          if ring1.name == ring2.name:
            continue
        
          playerHP = 100
          playerDamage = weapon.dmg + ring1.dmg + ring2.dmg
          playerArmor = armor.armor + ring1.armor + ring2.armor
          cost = weapon.cost + armor.cost + ring1.cost + ring2.cost

          if doesPlayerWin(playerHP, playerDamage, playerArmor):
            minCost = min(minCost, cost)
          else:
            maxCost = max(maxCost, cost)
  
  return minCost, maxCost